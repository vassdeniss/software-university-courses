const url = 'http://localhost:3030/jsonstore/collections/students';

document.getElementById('form').addEventListener('submit', addStudentAsync);

getStudentsAsync();

async function addStudentAsync(event) {
  event.preventDefault();

  const formData = new FormData(event.target);

  const { firstName, lastName, facultyNumber, grade } = Object.fromEntries(
    formData.entries()
  );

  if (!firstName || !lastName || !facultyNumber || !grade) {
    return;
  }

  const student = {
    firstName,
    lastName,
    facultyNumber,
    grade,
  };

  const options = {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(student),
  };

  try {
    const response = await fetch(url, options);

    if (!response.ok) {
      throw new Error();
    }

    getStudentsAsync();

    return await response.json();
  } catch (error) {
    console.log(error.message);
  }

  event.target.reset();
}

async function getStudentsAsync() {
  try {
    const response = await fetch(url);

    if (!response.ok) {
      throw new Error();
    }

    const json = await response.json();

    document.querySelector('#results tbody').innerHTML = '';
    Object.values(json).forEach((student) => {
      const tr = document.createElement('tr');

      tr.appendChild(createTableData(student.firstName));
      tr.appendChild(createTableData(student.lastName));
      tr.appendChild(createTableData(student.facultyNumber));
      tr.appendChild(createTableData(student.grade));

      document.querySelector('#results tbody').appendChild(tr);
    });
  } catch (error) {
    console.log(error.message);
  }

  function createTableData(data) {
    const td = document.createElement('td');
    td.textContent = data;

    return td;
  }
}
