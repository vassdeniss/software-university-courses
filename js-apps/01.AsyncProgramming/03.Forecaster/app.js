function attachEvents() {
  const getWeatherButton = document.getElementById('submit');

  const conditions = {
    Sunny: '&#x2600',
    'Partly sunny': '&#x26C5',
    Overcast: '&#x2601',
    Rain: '&#x2614',
    Degrees: '&#176;',
  };

  getWeatherButton.addEventListener('click', async () => {
    const locationInput = document.getElementById('location').value;
    document.getElementById('forecast').style.display = 'block';

    let code;
    debugger;
    try {
      code = await getLocation(locationInput);
    } catch (error) {
      document.getElementById('forecast').textContent = 'Error';
      return;
    }

    const today = await getTodayWeather(code);

    const forecastsDiv = document.createElement('div');
    forecastsDiv.classList.add('forecasts');

    const conditionSymbol = document.createElement('span');
    conditionSymbol.classList.add('condition');
    conditionSymbol.classList.add('symbol');
    conditionSymbol.innerHTML = conditions[today.forecast.condition];
    forecastsDiv.appendChild(conditionSymbol);

    const conditionSpan = document.createElement('span');
    conditionSpan.classList.add('condition');

    conditionSpan.appendChild(
      createElement('span', { classList: ['forecast-data'] }, today.name)
    );

    conditionSpan.appendChild(
      createElement(
        'span',
        { classList: ['forecast-data'] },
        `${today.forecast.low}&#176;/${today.forecast.high}${conditions.Degrees}`
      )
    );

    conditionSpan.appendChild(
      createElement(
        'span',
        { classList: ['forecast-data'] },
        today.forecast.condition
      )
    );

    forecastsDiv.appendChild(conditionSpan);

    document.getElementById('current').appendChild(forecastsDiv);

    const threeDay = await getUpcomingWeather(code);
    const fcInfoDiv = createElement('div', { classList: ['forecast-info'] });

    threeDay.forecast.forEach((el) => {
      const upcoming = createElement('span', { classList: ['upcoming'] });

      upcoming.appendChild(
        createElement(
          'span',
          { classList: ['symbol'] },
          conditions[el.condition]
        )
      );

      upcoming.appendChild(
        createElement(
          'span',
          { classList: ['forecast-data'] },
          `${el.low}${conditions.Degrees}/${el.high}${conditions.Degrees}`
        )
      );

      upcoming.appendChild(
        createElement('span', { classList: ['forecast-data'] }, el.condition)
      );

      fcInfoDiv.appendChild(upcoming);
    });

    document.getElementById('upcoming').appendChild(fcInfoDiv);
  });
}

async function getLocation(location) {
  const response = await fetch(
    'http://localhost:3030/jsonstore/forecaster/locations'
  );

  const json = await response.json();

  for (const obj of json) {
    if (obj.name === location) {
      return obj.code;
    }
  }

  throw new Error();
}

async function getTodayWeather(code) {
  const response = await fetch(
    `http://localhost:3030/jsonstore/forecaster/today/${code}`
  );

  return await response.json();
}

async function getUpcomingWeather(code) {
  const response = await fetch(
    `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`
  );

  return await response.json();
}

function createElement(type, props, content) {
  const element = document.createElement(type);
  Object.assign(element, props);

  if (content) {
    element.innerHTML = content;
  }

  return element;
}

attachEvents();
