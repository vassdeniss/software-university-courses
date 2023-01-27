function solve() {
  const text = document
    .getElementById('input')
    .value.split('.')
    .filter((s) => s.length > 0);

  const div = document.getElementById('output');
  for (let i = 0; i < text.length; i += 3) {
    let sentences = [];

    for (let j = 0; j < 3; j++) {
      if (text[i + j]) {
        sentences.push(text[i + j]);
      }
    }

    const paragraph = sentences.join('. ') + '.';
    div.innerHTML += `<p>${paragraph}</p>`;
  }
}
