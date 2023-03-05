function solve() {
  const departButton = document.getElementById('depart');
  const arriveButton = document.getElementById('arrive');
  const infoBox = document.getElementsByClassName('info')[0];

  let currentStopName = 'depot';
  let currentStopId = 'depot';

  async function depart() {
    departButton.disabled = true;
    arriveButton.disabled = false;

    try {
      infoBox.textContent = `Next stop ${await getNextStop(currentStopId)}`;
    } catch (error) {
      infoBox.textContent = 'Error';
      departButton.disabled = true;
      arriveButton.disabled = true;
    }
  }

  async function getNextStop(stop) {
    const response = await fetch(
      `http://localhost:3030/jsonstore/bus/schedule/${stop}`
    );

    if (!response.ok) {
      let error = new Error();
      error.status = response.status;
      error.statusText = response.statusText;

      throw error;
    }

    const json = await response.json();

    currentStopName = json.name;
    currentStopId = json.next;

    return json.name;
  }

  function arrive() {
    infoBox.textContent = `Arriving at ${currentStopName}`;
    departButton.disabled = false;
    arriveButton.disabled = true;
  }

  return {
    depart,
    arrive,
  };
}

let result = solve();
