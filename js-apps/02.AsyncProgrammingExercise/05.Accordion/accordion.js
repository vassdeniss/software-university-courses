async function solution() {
  const response = await fetch(
    'http://localhost:3030/jsonstore/advanced/articles/list'
  );

  const json = await response.json();

  Object.values(json).forEach((article) => {
    const accordionDiv = document.createElement('div');
    accordionDiv.classList.add('accordion');

    const headDiv = document.createElement('div');
    headDiv.classList.add('head');
    accordionDiv.appendChild(headDiv);

    const span = document.createElement('span');
    span.textContent = article.title;
    headDiv.appendChild(span);

    const moreButton = document.createElement('button');
    moreButton.classList.add('button');
    moreButton.id = article._id;
    moreButton.textContent = 'More';
    moreButton.addEventListener('click', fetchArticleInfoAsync);
    headDiv.appendChild(moreButton);

    const extraDiv = document.createElement('div');
    extraDiv.classList.add('extra');
    extraDiv.style.display = 'none';
    accordionDiv.appendChild(extraDiv);

    const p = document.createElement('p');
    extraDiv.appendChild(p);

    document.getElementById('main').appendChild(accordionDiv);

    async function fetchArticleInfoAsync() {
      const response = await fetch(
        `http://localhost:3030/jsonstore/advanced/articles/details/${this.id}`
      );

      const json = await response.json();

      if (extraDiv.style.display === 'none') {
        p.textContent = json.content;
        extraDiv.style.display = 'block';
        moreButton.textContent = 'Less';
      } else {
        p.textContent = '';
        moreButton.textContent = 'More';
        extraDiv.style.display = 'none';
      }
    }
  });
}

solution();
