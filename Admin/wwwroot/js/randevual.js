const body = document.querySelector("body");
const modal = document.querySelector(".modal");
const modalButton = document.querySelector(".modal-button");
const heartimage = document.querySelector("#heartimage");
const heartimage2 = document.querySelector("#heartimage2");
const hearthline = document.querySelector(".hearthline").style;
const closeButton = document.querySelector(".close-button");
const scrollDown = document.querySelector(".scroll-down");
let isOpened = false;

const openModal = () => {
    modal.classList.add("is-open");
    body.style.overflow = "hidden";
    heartimage.style.display = "none";
    heartimage2.style.display = "none";
    hearthline.backgroundSize = 0;
};

const closeModal = () => {
    modal.classList.remove("is-open");
    body.style.overflow = "initial";
    heartimage.style.display = "";
    heartimage2.style.display = "";
    hearthline.backgroundSize = "";
};
/*
window.addEventListener("scroll", () => {
    if (window.scrollY > window.innerHeight / 3 && !isOpened) {
        isOpened = true;
        scrollDown.style.display = "none";
        openModal();
    }
});*/

modalButton.addEventListener("click", openModal);
closeButton.addEventListener("click", closeModal);

document.onkeydown = evt => {
    evt = evt || window.event;
    evt.keyCode === 27 ? closeModal() : false;
};

