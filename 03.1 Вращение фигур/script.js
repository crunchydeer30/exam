// Получаем элемент контейнера для фигуры
const shapeContainer = document.getElementById("shapeContainer");

// Получаем элемент выбранной фигуры
const selectedShape = document.querySelector(".selected-shape");

// Получаем элемент ползунка скорости
const speedSlider = document.getElementById("speedSlider");

// Инициализация переменных для текущей фигуры и скорости
let currentShape = null;
let currentSpeed = 5;

// Функция для создания элемента фигуры и его добавления в контейнер
function createShape(shape) {
  const shapeElement = document.createElement("div");
  shapeElement.classList.add("shape");
  shapeElement.classList.add(shape);

  // Очищаем содержимое контейнера и добавляем новую фигуру
  shapeContainer.innerHTML = "";
  shapeContainer.appendChild(shapeElement);

  return shapeElement;
}

// Функция для обновления скорости анимации фигуры
function updateShapeSpeed() {
  if (currentShape) {
    currentShape.style.animationDuration = `${11 - currentSpeed}s`;
  }
}

// Функция для выбора фигуры
function selectShape(shape) {
  const shapeMap = {
    circle: "Круг",
    square: "Квадрат",
    triangle: "Треугольник",
    trapezoid: "Трапеция",
  };
  selectedShape.textContent = shapeMap[shape];
  currentShape = createShape(shape);
  updateShapeSpeed();
}

// Обработчик события изменения ползунка скорости
speedSlider.addEventListener("input", (e) => {
  currentSpeed = e.target.value;
  updateShapeSpeed();
});

// Инициализация с выбранной фигурой по умолчанию
selectShape("circle");
updateShapeSpeed();
