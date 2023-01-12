function isInLimit(speed, area) {
  const areas = {
    motorway: 130,
    interstate: 90,
    city: 50,
    residential: 20,
  };

  const areaSpeed = areas[area];

  if (speed <= areaSpeed) {
    console.log(`Driving ${speed} km/h in a ${areaSpeed} zone`);
  } else {
    const over = speed - areaSpeed;

    let status;
    if (over > 40) {
      status = 'reckless driving';
    } else if (over <= 40 && over > 20) {
      status = 'excessive speeding';
    } else {
      status = 'speeding';
    }

    console.log(
      `The speed is ${over} km/h faster than the allowed speed of ${areaSpeed} - ${status}`
    );
  }
}

isInLimit(40, 'city');
isInLimit(21, 'residential');
isInLimit(120, 'interstate');
isInLimit(200, 'motorway');
