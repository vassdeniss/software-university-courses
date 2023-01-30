function attachEventsListeners() {
  const input = document.getElementById('inputDistance');
  const inputUnit = document.getElementById('inputUnits');
  const output = document.getElementById('outputDistance');
  const outputUnit = document.getElementById('outputUnits');
  const convertButton = document.getElementById('convert');

  const meterConversion = {
    km: 1000,
    m: 1,
    cm: 0.01,
    mm: 0.001,
    mi: 1609.34,
    yrd: 0.9144,
    ft: 0.3048,
    in: 0.0254,
  };

  convertButton.addEventListener('click', () => {
    const from = inputUnit.value;
    const to = outputUnit.value;

    const fromInMeters = input.value * meterConversion[from];

    output.value = fromInMeters / meterConversion[to];
  });
}
