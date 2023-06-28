const taskForm = document.querySelector('.task-form');
const taskList = document.querySelector('.task-list');

let tasks;
let currentTaskId;

function main() {
  if (!localStorage.getItem('tasks')) {
    tasks = [];
    currentTaskId = 0;
  } else {
    tasks = JSON.parse(localStorage.getItem('tasks'));
    currentTaskId = tasks.at(-1).id;
  }

  console.log(tasks);

  renderTasks();
}

main();

taskForm.addEventListener('submit', (event) => {
  event.preventDefault();
  let newTask = {
    id: currentTaskId++,
    title: event.target.title.value,
    checked: false,
    date: event.target.date.value,
  };
  addTask(newTask);
  taskForm.title.value = '';
});

function addTask(newTask) {
  tasks.push(newTask);
  tasks.sort((a, b) => {
    return new Date(a.date) - new Date(b.date);
  });
  localStorage.setItem('tasks', JSON.stringify(tasks));
  renderTasks();
}

function renderTasks() {
  taskList.innerHTML = '';
  tasks.forEach((task) => {
    taskNode = document.createElement('li');
    taskNode.classList.add('task');
    taskNode.innerHTML = `
        <input type="checkbox" ${
          task.checked ? 'checked' : ''
        } onchange=checkTask(${task.id}) />
        <p>${task.title} (${task.date.toLocaleString('ru-RU')})</p>
        <button class="btn-delete" onclick=removeTask(${
          task.id
        })>Удалить</button>
    `;
    taskList.prepend(taskNode);
  });
}

function removeTask(id) {
  tasks = tasks.filter((task) => task.id !== id);
  localStorage.setItem('tasks', JSON.stringify(tasks));
  renderTasks();
}

function checkTask(id) {
  let task = tasks.find((task) => task.id === id);
  task.checked = !task.checked;
  localStorage.setItem('tasks', JSON.stringify(tasks));
}
