function getWalkingTime(steps, footprintMeters, kmSpeed) {
  let distance = steps * footprintMeters;
  let restTime = Math.floor(distance / 500) * 60;
  let mSpeed = kmSpeed / 3.6;

  let time = distance / mSpeed + restTime;

  let hours = Math.floor(time / 3600);
  let minutes = Math.floor(time / 60);
  let seconds = Math.round(time % 60);

  let printHours = `${hours < 10 ? '0' : ''}${hours}`;
  let printMinutes = `${minutes < 10 ? '0' : ''}${minutes}`;
  let printSeconds = `${seconds < 10 ? '0' : ''}${seconds}`;

  console.log(`${printHours}:${printMinutes}:${printSeconds}`);
}

getWalkingTime(4000, 0.6, 5);
getWalkingTime(2564, 0.7, 5.5);
