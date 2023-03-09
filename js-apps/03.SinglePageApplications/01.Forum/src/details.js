import { createElement } from './utils.js';

const section = document.getElementById('detailView');

const postElements = {
  title: section.querySelector('#details-title'),
  username: section.querySelector('#details-username'),
  time: section.querySelector('#details-time'),
  content: section.querySelector('#details-content'),
};

const commentList = section.querySelector('#user-comment');

const form = section.querySelector('form');
form.addEventListener('submit', createComment);

section.remove();

export function showDetails(event) {
  let target = event.target;

  if (target.tagName === 'H2') {
    target = target.parentElement;
  }

  if (target.tagName === 'A') {
    event.preventDefault();

    showPost(target.dataset.id);
  }
}

async function showPost(id) {
  document.getElementById('main').replaceChildren('Loading...');

  const [response, commentResponse] = await Promise.all([
    fetch(`http://localhost:3030/jsonstore/collections/myboard/posts/${id}`),
    fetch('http://localhost:3030/jsonstore/collections/myboard/comments'),
  ]);

  const [post, comments] = await Promise.all([
    response.json(),
    commentResponse.json(),
  ]);

  commentList.replaceChildren(
    ...Object.values(comments)
      .filter((comment) => comment.id === id)
      .map(createCommentElement)
  );

  form.id = id;
  postElements.title.textContent = post.title;
  postElements.username.textContent = post.username;
  postElements.time.textContent = post.createDate;
  postElements.content.textContent = post.post;

  document.getElementById('main').replaceChildren(section);
}

function createCommentElement(comment) {
  const fragment = document.createDocumentFragment();

  const nameWrapper = createElement('div', '', fragment, {
    class: 'topic-name-wrapper',
  });

  const name = createElement('div', '', nameWrapper, {
    class: 'topic-name',
  });

  const p = createElement('p', '', name, {});

  createElement('strong', comment.username, p, {});

  const text = document.createTextNode(' commented on ');
  p.appendChild(text);

  createElement('time', comment.createDate, p, {});

  const content = createElement('div', '', name, {
    class: 'post-content',
  });

  createElement('p', comment.content, content, {});

  return fragment;
}

async function createComment(event) {
  event.preventDefault();

  const formData = new FormData(form);

  const username = formData.get('username');
  const content = formData.get('postText');
  const id = form.id;

  try {
    if (!username || !content) {
      throw new Error('All fields are required');
    }

    const data = {
      username,
      content,
      id,
      createDate: new Date().toLocaleString(),
    };

    const options = {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data),
    };

    const response = await fetch(
      'http://localhost:3030/jsonstore/collections/myboard/comments/',
      options
    );

    if (!response.ok) {
      throw new Error(await response.json());
    }

    form.reset();

    showPost(id);
  } catch (error) {
    alert(error.message);
  }
}
