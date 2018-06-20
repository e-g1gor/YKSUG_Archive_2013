function equalHeight(group) {
  tallest = 0;
  group.each(function () {
    thisHeight = $(this).outerHeight();
    if (thisHeight > tallest) {
      tallest = thisHeight;
    }
  });
  group.height(tallest);
}
$(function () {
  $('.table-elements .container').hover(
    function () {
      $(this).children('.active').css('display', 'block');
    },
    function () {
      $(this).children('.active').css('display', 'none');
    });
});

$(window).load(function () {
  equalHeight($(".access-sidebar"));
  equalHeight($(".news-sidebar"));
  equalHeight($(".articles-sidebar"));
});
