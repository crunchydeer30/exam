let box = document.querySelector('.box');

let xAngle = 0;
let yAngle = 0;

window.addEventListener('keydown', (event) => {
  if (event.key === 'ArrowRight') {
    box.style.transform = `rotateY(${xAngle++}deg) rotateX(${yAngle}deg)`;
  }
  if (event.key === 'ArrowLeft') {
    box.style.transform = `rotateY(${xAngle--}deg) rotateX(${yAngle}deg)`;
  }
  if (event.key === 'ArrowUp') {
    box.style.transform = `rotateY(${xAngle}deg) rotateX(${yAngle++}deg)`;
  }
  if (event.key === 'ArrowDown') {
    box.style.transform = `rotateY(${xAngle}deg) rotateX(${yAngle--}deg)`;
  }
});
