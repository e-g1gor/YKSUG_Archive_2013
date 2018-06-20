$(document).ready(function() {
    //move he last list item before the first item. The purpose of this is if the user clicks to slide left he will be able to see the last item.
    $('#carousel_ul li:first').before($('#carousel_ul li:last')); 
    $('#carousel_ul li:first').before($('#carousel_ul li:last')); 
        
    //when user clicks the image for sliding right        
    $('#right_scroll').click(function(){
        
        //get the width of the items ( i like making the jquery part dynamic, so if you change the width in the css you won't have o change it here too ) '
        var item_width = $('#carousel_ul li').outerWidth();// + 10;
			
        //calculae the new left indent of the unordered list
        var left_indent = parseInt($('#carousel_ul').css('left')) - item_width;
       
        //make the sliding effect using jquery's anumate function '
        $('#carousel_ul:not(:animated)').animate({'left' : -1260},500,function(){    
            //get the first list item and put it after the last list item (that's how the infinite effects is made) '
            $('#carousel_ul li:last').after($('#carousel_ul li:first')); 
                
            //and get the left indent to the default -210px
            $('#carousel_ul').css({'left' : '-630px'});
    
            //get the first list item and put it after the last list item (that's how the infinite effects is made) '
            $('#carousel_ul li:last').after($('#carousel_ul li:first')); 
                
            //and get the left indent to the default -210px
            $('#carousel_ul').css({'left' : '-630px'});				
        }); 
    });
        
    //when user clicks the image for sliding left
    $('#left_scroll').click(function(){
        var item_width = $('#carousel_ul li').outerWidth();// + 10;
        var left_indent = parseInt($('#carousel_ul').css('left')) + item_width; //left_indent = 0;
          
        $('#carousel_ul').animate({'left' : 0},500,function(){    
			$('#carousel_ul li:first').before($('#carousel_ul li:last')); 
			$('#carousel_ul').css({'left' : '-630px'});
 
			$('#carousel_ul li:first').before($('#carousel_ul li:last')); 
			$('#carousel_ul').css({'left' : '-630px'});
        });
    });
});