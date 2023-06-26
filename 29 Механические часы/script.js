const clock = document.querySelector('.clock');
const secondHand = document.querySelector('.second-hand');
const minuteHand = document.querySelector('.minute-hand');
const hourHand = document.querySelector('.hour-hand');

function handleClock() {
  currentTimestamp = new Date();
  second = currentTimestamp.getSeconds();
  minute = currentTimestamp.getMinutes();
  hour = currentTimestamp.getHours();
  console.log(hour);
  secondHand.style.transform = `translateX(-50%) rotate(${second * 6}deg)`;
  minuteHand.style.transform = `translateX(-50%) rotate(${minute * 6}deg)`;
  hourHand.style.transform = `translateX(-50%) rotate(${hour * 30}deg)`;
}

setInterval(handleClock, 1000);
