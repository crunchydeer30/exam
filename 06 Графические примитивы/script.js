const canvas = document.querySelector('canvas');
const ctx = canvas.getContext('2d');
const toolSelector = document.getElementById('tool-selector');

let isDrawing = false;
let brushWidth = 5;
let selectedColor = '#000';
let selectedTool = 'brush';

let prevMouseX, prevMouseY;

toolSelector.addEventListener('change', () => {
  selectedTool = toolSelector.tool.value;
});

window.addEventListener('load', () => {
  canvas.style.width = '100%';
  canvas.style.height = '100%';
  canvas.width = canvas.offsetWidth;
  canvas.height = canvas.offsetHeight;
  setCanvasBackground();
});

function setCanvasBackground() {
  ctx.fillStyle = '#fff';
  ctx.fillRect(0, 0, canvas.width, canvas.height);
  ctx.fillStyle = selectedColor;
}

function drawRect(event) {
  ctx.fillRect(e);
}

canvas.addEventListener('mousedown', startDraw);
canvas.addEventListener('mousemove', drawing);
canvas.addEventListener('mouseup', () => {
  isDrawing = false;
});

function startDraw(event) {
  isDrawing = true;
  prevMouseX = event.offsetX;
  prevMouseY = event.offsetY;

  ctx.beginPath();
  ctx.lineWidth = brushWidth;
  ctx.strokeStyle = selectedColor;
  ctx.fillStyle = selectedColor;
}

function stopDraw(event) {
  isDrawing = false;
}

function drawBrush(event) {
  ctx.strokeStyle = selectedColor;
  ctx.lineTo(event.offsetX, event.offsetY);
  ctx.stroke();
}

function drawRect(event) {
  ctx.fillRect(
    event.offsetX,
    event.offsetY,
    prevMouseX - event.offsetX,
    prevMouseY - event.offsetY
  );
}

function drawCircle(event) {
  ctx.beginPath();

  let radius = Math.sqrt(
    Math.pow(prevMouseX - event.offsetX, 2) +
      Math.pow(prevMouseY - event.offsetY, 2)
  );

  console.log(radius);

  ctx.arc(prevMouseX, prevMouseY, radius, 0, 2 * Math.PI);
  ctx.stroke();
}

function drawing(event) {
  if (isDrawing) {
    if (selectedTool == 'brush') {
      drawBrush(event);
    }
    if (selectedTool == 'rectangle') {
      drawRect(event);
    }
    if (selectedTool == 'circle') {
      drawCircle(event);
    }
  } else {
    return;
  }
}
