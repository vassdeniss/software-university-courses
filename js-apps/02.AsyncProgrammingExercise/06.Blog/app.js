async function attachEvents() {
  const posts = document.getElementById('posts');
  const comments = document.getElementById('post-comments');

  const postsArr = [];
  document
    .getElementById('btnLoadPosts')
    .addEventListener('click', async () => {
      const response = await fetch(
        'http://localhost:3030/jsonstore/blog/posts'
      );

      const json = await response.json();

      posts.innerHTML = '';
      Object.entries(json).forEach(([id, post]) => {
        const option = document.createElement('option');

        option.value = id;
        option.textContent = post.title;

        posts.appendChild(option);
        postsArr.push({ title: post.title, body: post.body });
      });
    });

  document.getElementById('btnViewPost').addEventListener('click', async () => {
    const title = posts.selectedOptions[0].textContent;
    document.getElementById('post-title').textContent = title;
    document.getElementById('post-body').textContent = postsArr.filter(
      (p) => p.title === title
    )[0].body;

    const commentResponse = await fetch(
      'http://localhost:3030/jsonstore/blog/comments/'
    );

    const commentJson = await commentResponse.json();

    comments.innerHTML = '';

    Object.values(commentJson).forEach((comment) => {
      if (comment.postId === posts.value) {
        const li = document.createElement('li');
        li.textContent = comment.text;
        comments.appendChild(li);
      }
    });
  });
}

attachEvents();
