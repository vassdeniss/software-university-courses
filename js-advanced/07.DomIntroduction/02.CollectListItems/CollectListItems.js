function extractText() {
  const listNodes = document.querySelectorAll('#items li');

  const textArea = document.getElementById('result');
  for (const node of Array.from(listNodes)) {
    textArea.value += node.textContent + '\n';
  }
}
