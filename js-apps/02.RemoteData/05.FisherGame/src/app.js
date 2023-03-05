const userData = JSON.parse(localStorage.getItem('userData'));

if (userData) {
  document.querySelector('.email span').textContent = userData.email;
  document.querySelector('#guest').style.display = 'none';
  document.querySelector('#addForm .add').disabled = false;
} else {
  document.getElementById('user').style.display = 'none';
}

await loadCatchesAsync();

document.querySelector('.load').addEventListener('click', loadCatchesAsync);

async function loadCatchesAsync() {
  try {
    const response = await fetch('http://localhost:3030/data/catches');

    const json = await response.json();

    if (!response.ok) {
      throw new Error(json.message);
    }

    document
      .getElementById('catches')
      .replaceChildren(...json.map(createCatch));
  } catch (error) {
    alert(error.message);
  }
}

function createCatch(jsonCatch) {
  const isDisabled =
    userData && jsonCatch._ownerId === userData.id ? false : true;
  return createElement(
    'div',
    { class: 'catch' },
    createElement('label', {}, 'Angler'),
    createElement('input', {
      type: 'text',
      class: 'angler',
      value: jsonCatch.angler,
      disabled: isDisabled,
    }),
    createElement('label', {}, 'Weight'),
    createElement('input', {
      type: 'text',
      class: 'weight',
      value: jsonCatch.weight,
      disabled: isDisabled,
    }),
    createElement('label', {}, 'Species'),
    createElement('input', {
      type: 'text',
      class: 'species',
      value: jsonCatch.species,
      disabled: isDisabled,
    }),
    createElement('label', {}, 'Location'),
    createElement('input', {
      type: 'text',
      class: 'location',
      value: jsonCatch.location,
      disabled: isDisabled,
    }),
    createElement('label', {}, 'Bait'),
    createElement('input', {
      type: 'text',
      class: 'bait',
      value: jsonCatch.bait,
      disabled: isDisabled,
    }),
    createElement('label', {}, 'Capture Time'),
    createElement('input', {
      type: 'number',
      class: 'captureTime',
      value: jsonCatch.captureTime,
      disabled: isDisabled,
    }),
    createElement(
      'button',
      { class: 'update', id: jsonCatch._id, disabled: isDisabled },
      'Update'
    ),
    createElement(
      'button',
      { class: 'delete', id: jsonCatch._id, disabled: isDisabled },
      'Delete'
    )
  );
}

function createElement(type, attr, ...content) {
  const element = document.createElement(type);

  Object.entries(attr).forEach(([key, value]) => {
    if (key === 'class') {
      element.classList.add(value);
    } else if (key === 'disable') {
      element.disabled = value;
    } else {
      element[key] = value;
    }
  });

  content.forEach((item) => {
    if (typeof item === 'string' || typeof item === 'number') {
      item = document.createTextNode(item);
    }

    element.appendChild(item);
  });

  return element;
}

document.getElementById('addForm').addEventListener('submit', createCatchAsync);

async function createCatchAsync(event) {
  event.preventDefault();

  if (!userData) {
    window.location = './login.html';
    return;
  }

  const formData = new FormData(event.target);

  const { angler, weight, species, location, bait, captureTime } =
    Object.fromEntries(formData.entries());

  event.target.reset();

  try {
    if (!angler || !weight || !species || !location || !bait || !captureTime) {
      throw new Error('Missing fields!');
    }

    const data = {
      angler,
      weight,
      species,
      location,
      bait,
      captureTime,
    };

    const options = {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'X-Authorization': userData.token,
      },
      body: JSON.stringify(data),
    };

    const response = await fetch('http://localhost:3030/data/catches', options);

    const json = await response.json();

    if (!response.ok) {
      throw new Error(json.message);
    }

    await loadCatchesAsync();

    return json;
  } catch (error) {
    alert(error.message);
  }
}

document.querySelector('#main').addEventListener('click', delegateButtons);

function delegateButtons(event) {
  const button = event.target.textContent;
  const id = event.target.id === '' ? event.target.dataset.id : event.target.id;
  const currentCatch = event.target.parentElement;

  if (button === 'Delete') {
    deleteCatchAsync(id);
  } else if (button === 'Update') {
    updateCatchAsync(id, currentCatch);
  }
}

async function deleteCatchAsync(id) {
  const options = {
    method: 'DELETE',
    headers: {
      'Content-Type': 'application/json',
      'X-Authorization': userData.token,
    },
  };

  await fetch(`http://localhost:3030/data/catches/${id}`, options);

  await loadCatchesAsync();
}

async function updateCatchAsync(id, element) {
  const [angler, weight, species, location, bait, captureTime] =
    element.querySelectorAll('input');

  try {
    if (
      !angler.value ||
      !weight.value ||
      !species.value ||
      !location.value ||
      !bait.value ||
      !captureTime.value
    ) {
      throw new Error('Missing fields!');
    }

    const data = {
      angler: angler.value,
      weight: weight.value,
      species: species.value,
      location: location.value,
      bait: bait.value,
      captureTime: captureTime.value,
    };

    const options = {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
        'X-Authorization': userData.token,
      },
      body: JSON.stringify(data),
    };

    const response = await fetch(
      `http://localhost:3030/data/catches/${id}`,
      options
    );

    const json = await response.json();

    if (!response.ok) {
      throw new Error(json.message);
    }

    await loadCatchesAsync();

    return json;
  } catch (error) {
    alert(error.message);
  }
}

document.getElementById('logout').addEventListener('click', logOutAsync);

async function logOutAsync() {
  const options = {
    headers: {
      'X-Authorization': userData.token,
    },
  };

  await fetch('http://localhost:3030/users/logout', options);

  localStorage.clear();

  document.querySelector('#logout').style.display = 'none';
  document.querySelector('#addForm .add').disabled = true;
  document.querySelector('#guest').style.display = 'block';

  window.location.reload();
}
