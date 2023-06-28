const taskForm = document.getElementById('task-form');
const taskList = document.querySelector('.task-list');

let tasks = [];

taskForm.addEventListener('submit', (event) => {
  event.preventDefault();
  createTask(event.target.title.value);
});

async function createTask(title) {
  await fetch('http://127.0.0.1:8000/tasks', {
    method: 'POST',
    body: new URLSearchParams({
      title: title,
    }),
  });
}

async function loadTasks() {
  await fetch('http://127.0.0.1:8000/tasks')
    .then((response) => {
      if (!response.ok) {
        throw new Error();
      }
      return response.json();
    })
    .then((data) => {
      tasks = data;
    });
}

function renderTasks() {
  console.log(tasks);
  tasks.forEach((task) => {
    taskNode = document.createElement('li');
    taskNode.classList.add('task');
    taskNode.innerHTML = `
      <input type="checkbox" onchange=checkTask(${task.id}) ${
      task.checked ? 'checked' : ''
    } />
      <p>${task.title}</p>
      <button class="delete-btn" onclick=removeTask(${task.id})>Удалить</button>
    `;
    taskList.prepend(taskNode);
  });
}

async function checkTask(id) {
  await fetch(`http://127.0.0.1:8000/tasks/${id}`, {
    method: 'PUT',
  }).then((response) => {
    console.log(response);
  });
}

async function removeTask(id) {
  await fetch(`http://127.0.0.1:8000/tasks/${id}`, {
    method: 'DELETE',
  }).then((response) => {
    console.log(response);
  });
}

async function main() {
  await loadTasks();
  renderTasks();
}

main();
