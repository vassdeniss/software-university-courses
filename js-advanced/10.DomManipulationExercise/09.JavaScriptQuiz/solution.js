function solve() {
  const correctAnswers = [
    'onclick',
    'JSON.stringify()',
    'A programming API for HTML and XML documents',
  ];
  const sections = document.getElementsByTagName('section');
  let answers = 0;
  let index = 0;

  Array.from(document.getElementsByClassName('answer-text')).forEach((p) =>
    p.addEventListener('click', (event) => {
      if (correctAnswers.includes(event.target.textContent.trim())) {
        answers++;
      }

      sections[index++].style.display = 'none';

      if (sections[index] !== undefined) {
        sections[index].style.display = 'block';
      } else {
        const result = document.getElementById('results');
        result.style.display = 'block';

        result.querySelector('h1').textContent =
          answers !== 3
            ? `You have ${answers} right answers`
            : 'You are recognized as top JavaScript fan!';
      }
    })
  );
}
