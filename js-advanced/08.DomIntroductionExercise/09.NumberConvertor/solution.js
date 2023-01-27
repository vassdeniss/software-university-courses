function solve() {
  const firstOptionElement = document.createElement('option');
  const secondOptionElement = document.createElement('option');

  firstOptionElement.value = 'binary';
  firstOptionElement.textContent = 'Binary';
  secondOptionElement.value = 'hexadecimal';
  secondOptionElement.textContent = 'Hexadecimal';

  const menu = document.getElementById('selectMenuTo');
  menu.appendChild(firstOptionElement);
  menu.appendChild(secondOptionElement);

  const button = document.getElementsByTagName('button')[0];
  button.addEventListener('click', () => {
    const input = document.getElementById('input');

    const output = document.getElementById('result');
    if (menu.value === 'binary') {
      output.value = Number(input.value).toString(2);
    } else if (menu.value === 'hexadecimal') {
      output.value = Number(input.value).toString(16).toUpperCase();
    }
  });
}
