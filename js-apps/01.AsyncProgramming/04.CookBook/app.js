window.addEventListener('load', async () => {
  const main = document.querySelector('main');

  const recipes = await getRecipes();
  const cards = recipes.map(createRecipePreview);

  console.log(recipes);

  main.textContent = '';
  cards.forEach((card) => main.appendChild(card));
});

async function getRecipes() {
  const response = await fetch(
    'http://localhost:3030/jsonstore/cookbook/recipes'
  );

  const json = await response.json();

  return Object.values(json);
}

function createRecipePreview(recipe) {
  const result = createElement(
    'article',
    { className: 'preview', onClick: toggleCard },
    createElement(
      'div',
      { className: 'title' },
      createElement('h2', {}, recipe.name)
    ),
    createElement(
      'div',
      { className: 'small' },
      createElement('img', { src: recipe.img })
    )
  );

  async function toggleCard() {
    const fullRecipe = await getRecipeById(recipe._id);

    result.replaceWith(createRecipeElement(fullRecipe));
  }

  return result;
}

async function getRecipeById(id) {
  const response = await fetch(
    `https://localhost:3030/jsonstore/cookbook/details/${id}`
  );

  const recipe = await response.json();

  return recipe;
}

function createRecipeElement(recipe) {
  return createElement(
    'article',
    {},
    createElement('h2', {}, recipe.name),
    createElement(
      'div',
      { className: 'band' },
      createElement(
        'div',
        { className: 'thumb' },
        createElement('img', { src: recipe.img })
      ),
      createElement(
        'div',
        { className: 'ingredients' },
        createElement('h3', {}, 'Ingredients:'),
        createElement(
          'ul',
          {},
          recipe.ingredients.map((ingredient) =>
            createElement('li', {}, ingredient)
          )
        )
      )
    ),
    createElement(
      'div',
      { className: 'description' },
      createElement('h3', {}, 'Preparation:'),
      recipe.steps.map((step) => createElement('p', {}, step))
    )
  );
}

function createElement(type, attributes, ...content) {
  const element = document.createElement(type);

  for (const [key, value] of Object.entries(attributes)) {
    if (key.substring(0, 2) == 'on') {
      element.addEventListener(key.substring(2).toLocaleLowerCase(), value);
    } else {
      element[key] = value;
    }
  }

  content = content.reduce(
    (acc, curr) => acc.concat(Array.isArray(curr) ? curr : [curr]),
    []
  );

  content.forEach((el) => {
    if (typeof el == 'string' || typeof el == 'number') {
      const node = document.createTextNode(el);
      element.appendChild(node);
    } else {
      element.appendChild(el);
    }
  });

  return element;
}
