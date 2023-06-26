const imageForm = document.getElementById('image-form');
const imageGrid = document.querySelector('.image-grid');
const imageInput = document.querySelector('#image-input');
let images = [];

imageForm.addEventListener('submit', (event) => {
  event.preventDefault();
  const images = imageInput.files;

  for (let i = 0; i < images.length; i++) {
    const imageUrl = URL.createObjectURL(images[i]);
    saveImage(imageUrl);
  }

  imageInput.value = '';
  renderImages();
});

function saveImage(imagePath) {
  images.push(imagePath);
}

function renderImages() {
  imageGrid.innerHTML = '';
  images.forEach((image) => {
    imageContainer = document.createElement('article');
    imageContainer.innerHTML = `
      <article class="image">
        <img src='${image}'>
      </acticle>
    `;
    imageGrid.prepend(imageContainer);
  });
}
