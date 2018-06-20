(function($){

    $.soliHomeSliderTop = function(elem, options){
		var SLIDE_INTERVAL = 5000;
	
        var base = this;
        base.$box = $(elem);
        base.information = {
            $informations: $('.information', base.$box),
            active: 0
        };
        base.accordion = {
            $box: $('.accordion', base.$box),
            $items: $('.accordion > .item', base.$box),
            locked: false
        };
        base.slider = {
            $sliders: $('.slider', base.accordion.$items),
            locked: false
        };

		base.showNext = function(){
			var $boxCurrent = $('.accordion > .item.active');
			var $elementCurrent = $('li > a.active', $boxCurrent);
			var $boxs = base.accordion.$items;
			var $elements = $('li > a', $boxCurrent);
			var boxIndex = $boxs.index($boxCurrent);
			var elementIndex = $elements.index($elementCurrent);
			
			if (elementIndex < $elements.length - 1) {
				// go to next element
				$elements.eq(elementIndex + 1).click();
			} else {
				// go to next accordion
				var $boxNext = $boxs.eq((boxIndex + 1) % $boxs.length);
				$boxNext.find('.title').click();
				$boxNext.find('li > a:first').click();
			}
		};

        base.showInformation = function(){
            var activeNum = base.information.active % 2;
            var noActiveNum = (base.information.active + 1) % 2;

            var $informationActive = $( base.information.$informations.get(activeNum) );
            var $informationNoActive = $( base.information.$informations.get(noActiveNum) );

            $informationNoActive.hide();
            $informationNoActive.addClass('active');

            $informationActive.fadeOut(base.options.duration, function(){
                $informationActive.removeClass('active');
            });
            $informationNoActive.fadeIn(base.options.duration, function(){
                base.slider.locked = false;
            });

            base.information.active = noActiveNum;
        };

        base.initSliders = function(){
            base.slider.$sliders.each(function(){
                var $elem = $(this);

                var sliderWidth = $elem.outerWidth(true);
                var outerWidth = $elem.closest('.item').innerWidth();

                $elem.css('left', ((outerWidth - sliderWidth) / 2) + 'px');
            });

            $('a', base.slider.$sliders).on('click', function(){
                var $elem = $(this);

				base.initTimeout();
				
                if (! base.slider.locked && ! $elem.hasClass('active')) {
                    base.slider.locked = true;

                    var $elemActive = base.slider.$sliders.find('.active');

                    $elemActive.removeClass('active');
                    $elem.addClass('active');
                    $.ajax({
                        url: $elem.attr('href').slice(1),
                        dataType: 'html',
                        success: function(data){
                            var noActiveNum = (base.information.active + 1) % 2;
                            var $informationNoActive = $( base.information.$informations.get(noActiveNum) );
							var dat=data.split(':');
							var temp=dat[1]+':'+dat[2];
							var dat2=temp.split('"');
							var image=dat2[1].replace(/\\/g, '');
							
							var temp2=dat[4]+':'+dat[5];
							var dat3=temp2.replace(/\\/g, '').split('"');
							var text=dat3[1]+'"'+dat3[2]+'"'+dat3[3];
                            // @TODO: insert video
                            $('.text > .outer', $informationNoActive).html(text || '');
                            $('.background-image > img', $informationNoActive)
                                    .off('mousedown')
                                    .off('load')
                                    .off('error')
                                    .remove();
                            
                            if (image) {
                                $('<img/>')
                                        .on('mousedown', function(event){
                                            if (event.preventDefault) {
                                                event.preventDefault();
                                            }
                                            return false;
                                        })
                                        .on('load', function(){
                                            $('.background-image', $informationNoActive).append(this);
                                            base.showInformation();
                                        })
                                        .on('error', function(){
                                            console.log('slider load image error');
                                            base.showInformation();
                                        })
                                        .attr('src', image || '');
                            } else {
                                base.showInformation();
                            }
                        },
                        error: function(){
                            console.log('slider ajax error');
                            base.slider.locked = false;
                        }
                    });
                }

                return false;
            });
            $('a', base.slider.$sliders.get(0)).get(0).click();
        };

		base.initTimeout = function(){
			if (base.timeout) {
				clearTimeout(base.timeout);
			}
			base.timeout = setTimeout(base.showNext, SLIDE_INTERVAL);
		};
		
        base.initAccordion = function(){
            $('.title', base.accordion.$items).on('click', function(){
                var $item = $(this).closest('.item');

                if (! base.accordion.locked && ! $item.hasClass('active')) {
                    base.accordion.locked = true;

                    var $outer = $('.outer', $item);
                    var $itemActive = $('.item.active', base.accordion.$box);
                    var $outerActive = $('.outer', $itemActive);

                    var itemHeight = $item.outerHeight(true);
                    var accordionHeight = base.accordion.$box.innerHeight();
                    var outerHeigth = accordionHeight - itemHeight * base.accordion.$items.size();
                    
                    $outer.height(0);
                    $itemActive.removeClass('active');
                    $item.addClass('active');
                    $outerActive.animate({height: 0}, base.options.duration);
                    $outer.animate({height: outerHeigth + 'px'}, base.options.duration, function(){
                        base.accordion.locked = false;
                    });
                }

                return false;
            });
            $('.title', base.accordion.$items.get(0)).get(0).click();
        };
        
        base.init = function(){
            base.options = $.extend({}, $.soliHomeSliderTop.defaultOptions, options);
            
            base.initSliders();
            base.initAccordion();
        };
        
        base.init();
    };
    
    $.soliHomeSliderTop.defaultOptions = {
        duration: 500
    };
    
    $.fn.soliHomeSliderTop = function(options){
        return this.each(function(){
            (new $.soliHomeSliderTop(this, options));
        });
    };
    
})(jQuery);
