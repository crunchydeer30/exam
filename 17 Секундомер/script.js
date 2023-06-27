const stopwatch = document.querySelector(".stopwatch");
const h1 = stopwatch.querySelector("h1");
const startBtn = stopwatch.querySelector(".start");
const stopBtn = stopwatch.querySelector(".stop");
const resetBtn = stopwatch.querySelector(".reset");

let startTime;
let elapsedTime = 0;
let intervalId;

function print(str) {
  h1.textContent = str;
}

function start() {
  startTime = Date.now() - elapsedTime;
  intervalId = setInterval(function () {
    elapsedTime = Date.now() - startTime;
    const formattedTime = new Date(elapsedTime).toISOString().slice(11, -1);
    print(formattedTime);
  }, 10);
  startBtn.disabled = true;
  stopBtn.disabled = false;
}

function stop() {
  clearInterval(intervalId);
  startBtn.disabled = false;
  stopBtn.disabled = true;
}

function reset() {
  clearInterval(intervalId);
  elapsedTime = 0;
  print("00:00:00");
  startBtn.disabled = false;
  stopBtn.disabled = true;
}

startBtn.addEventListener("click", start);
stopBtn.addEventListener("click", stop);
resetBtn.addEventListener("click", reset);