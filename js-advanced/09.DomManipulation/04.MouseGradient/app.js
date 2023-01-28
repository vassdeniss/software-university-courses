function attachGradientEvents() {
  const gradient = document.getElementById('gradient');

  gradient.addEventListener('mousemove', gradientMove);

  const result = document.getElementById('result');
  function gradientMove(event) {
    const power = event.offsetX / (event.target.clientWidth - 1);
    result.textContent = `${Math.trunc(power * 100)}%`;
  }

  gradient.addEventListener('mouseout', function (event) {
    result.textContent = '';
  });
}
