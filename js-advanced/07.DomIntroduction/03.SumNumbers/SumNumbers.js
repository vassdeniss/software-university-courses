function calc() {
  const numberOne = document.getElementById('num1').value;
  const numberTwo = document.getElementById('num2').value;

  const resultText = document.getElementById('sum');
  resultText.value = Number(numberOne) + Number(numberTwo);
}
