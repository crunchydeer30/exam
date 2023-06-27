let alarmSound = document.getElementById('alarm-sound');

function setAlarm() {
 let hour = document.getElementById('hour').value;
 let minute = document.getElementById('minute').value;
 let second = document.getElementById('second').value;

 if (hour == '' || minute == '' || second == '') {
  alert('Введите время для сигнала');
  return;
 }

 let now = new Date();
 let alarmTime = new Date();
 alarmTime.setHours(hour);
 alarmTime.setMinutes(minute);
 alarmTime.setSeconds(second);

 let timeToAlarm = alarmTime - now;

 if (timeToAlarm < 0) {
  alert('Время для сигнала уже прошло');
  return;
 }

 setTimeout(function() {
  alarmSound.play();
  alert('Сигнал сработал');
 }, timeToAlarm);
}

function stopAlarm() {
 alarmSound.pause();
 alarmSound.currentTime = 0;
}