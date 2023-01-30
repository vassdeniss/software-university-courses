function create(words) {
  const content = document.getElementById('content');
  words.forEach((word) => {
    const div = document.createElement('div');
    const p = document.createElement('p');

    p.style.display = 'none';
    p.textContent = word;

    div.appendChild(p);

    div.addEventListener('click', () => {
      p.style.display = 'inline';
    });

    content.appendChild(div);
  });
}
