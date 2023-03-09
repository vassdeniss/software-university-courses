import { showSection } from './router.js';
import { showDetails } from './details.js';
import { getIdeas } from './endpoints.js';
import { createElement } from './util.js';

const section = document.getElementById('dashboard-holder');

export async function showDashboard(event) {
  event?.preventDefault();

  const ideas = await getIdeas();

  if (ideas.length > 0) {
    section.replaceChildren(...Object.values(ideas).map(createIdeaElement));
  } else {
    createElement('h1', 'No ideas yet! Be the first one :)', section, {});
  }

  showSection(section);
}

function createIdeaElement(idea) {
  const fragment = document.createDocumentFragment();

  const div = createElement('div', '', fragment, {
    class: 'card overflow-hidden current-card details',
    style: 'width: 20rem; height: 18rem',
  });

  const body = createElement('div', '', div, {
    class: 'card-body',
  });

  createElement('p', idea.title, body, {
    class: 'card-text',
  });

  createElement('img', '', div, {
    class: 'card-image',
    src: idea.img,
    alt: 'Card image cap',
  });

  const a = createElement('a', 'Details', div, {
    class: 'btn',
    href: '',
  });
  a.addEventListener('click', (event) => showDetails(event, idea._id));

  return fragment;
}
