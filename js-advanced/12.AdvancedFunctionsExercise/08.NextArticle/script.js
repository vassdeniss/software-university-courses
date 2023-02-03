function getArticleGenerator(articles) {
  let allArticles = [...articles];

  const div = document.getElementById('content');

  return () => {
    if (allArticles.length === 0) {
      return;
    }

    const article = document.createElement('article');
    article.textContent = allArticles.shift();
    div.appendChild(article);
  };
}
