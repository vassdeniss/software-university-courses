import { createElement } from './utils.js';
import { showDetails } from './details.js';

const section = document.getElementById('homeView');
section.remove();

const topicDiv = section.querySelector('.topic-title');
topicDiv.addEventListener('click', showDetails);

const topicUrl = 'http://localhost:3030/jsonstore/collections/myboard/posts';

const form = section.querySelector('form');
form.addEventListener('submit', createTopic);

form.querySelector('.cancel').addEventListener('click', clearForm);

export async function showHome(event) {
  event?.preventDefault();

  document.getElementById('main').replaceChildren(section);

  try {
    const response = await fetch(topicUrl);

    const json = await response.json();

    if (!response.ok) {
      throw new Error(json.message);
    }

    topicDiv.replaceChildren(...Object.values(json).map(createTopicElement));
  } catch (error) {
    alert(error.message);
  }
}

async function createTopic(event) {
  event.preventDefault();

  const formData = new FormData(form);

  const { topicName, username, postText } = Object.fromEntries(
    formData.entries()
  );

  try {
    if (!topicName || !username || !postText) {
      throw new Error('All fields are required!');
    }

    const data = {
      title: topicName,
      username,
      content: postText,
      createDate: new Date().toLocaleString(),
    };

    const options = {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data),
    };

    const response = await fetch(topicUrl, options);

    if (!response.ok) {
      throw new Error(await response.json());
    }

    form.reset();
    showHome();
  } catch (error) {
    alert(error.message);
  }
}

function createTopicElement(topic) {
  const fragment = document.createDocumentFragment();

  const container = createElement('div', '', fragment, {
    class: 'topic-container',
  });

  const nameWrapper = createElement('div', '', container, {
    class: 'topic-name-wrapper',
  });

  const topicName = createElement('div', '', nameWrapper, {
    class: 'topic-name',
  });

  const a = createElement('a', '', topicName, {
    href: '#',
    class: 'normal',
    'data-id': topic._id,
  });

  createElement('h2', topic.title, a, {});

  const columns = createElement('div', '', topicName, {
    class: 'columns',
  });

  const div = createElement('div', '', columns, {});

  const date = createElement('p', 'Date: ', div, {});

  createElement('time', topic.createDate, date, {});

  const nickName = createElement('div', '', div, {
    class: 'nick-name',
  });

  const name = createElement('p', 'Username: ', nickName, {});

  createElement('span', topic.username, name, {});

  return fragment;
}

function clearForm(event) {
  event.preventDefault();

  form.reset();
}
