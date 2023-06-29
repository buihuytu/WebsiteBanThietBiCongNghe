const listItem = document.querySelector('.product-list');
const item = document.getElementById('hidden-product');
document.addEventListener('click', (e) => {
    if (listItem.contains(e.target)) {
        item.classList.toggle('overflow-hidden')
    }

});

// swiper
var swiper = new Swiper(".mySwiper", {
    spaceBetween: 30,
    centeredSlides: true,
    autoplay: {
        delay: 2500,
        disableOnInteraction: false,
    },

    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
});

$('.slick').slick({
    infinite: true,
    autoplay: true,
    autoplaySpeed: 2000,
    slidesToShow: 5,
    slidesToScroll: 1,
    nextArrow: '<div class="swiper-button-next" style="margin-right:-40px !important;"></div>',
    prevArrow: '<div class="swiper-button-prev" style="margin-left:-40px !important;"></div>'
});