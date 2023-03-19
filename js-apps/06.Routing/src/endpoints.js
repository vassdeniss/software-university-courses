import { get, post, put, del } from './api.js';

export async function getFurniture() {
  return await get('/data/catalog');
}

export async function getUserFurniture(id) {
  return await get(`/data/catalog?where=_ownerId%3D%22${id}%22`);
}

export async function getFurnitureById(id) {
  return await get(`/data/catalog/${id}`);
}

export async function createFurniture(data) {
  const errorInputs = validateFurniture(data);

  if (!errorInputs.length > 0) {
    throw {
      errorInputs,
    };
  }

  await post('/data/catalog', {
    make: data.make,
    model: data.model,
    year: data.year,
    description: data.description,
    price: data.price,
    img: data.img,
    material: data.material,
  });
}

export async function editFurniture(data) {
  const errorInputs = validateFurniture(data);

  if (errorInputs.length > 0) {
    throw {
      errorInputs,
    };
  }

  await put(`/data/catalog/${data.id}`, {
    make: data.make,
    model: data.model,
    year: data.year,
    description: data.description,
    price: data.price,
    img: data.img,
    material: data.material,
  });
}

function validateFurniture(data) {
  const errorInputs = [];

  if (data.make.length < 4) {
    errorInputs.push('make');
  }

  if (data.model.length < 4) {
    errorInputs.push('model');
  }

  if (!data.year || Number(data.year) < 1950 || Number(data.year) > 2050) {
    errorInputs.push('year');
  }

  if (data.description.length <= 10) {
    errorInputs.push('description');
  }

  if (!data.price || Number(data.price) < 0) {
    errorInputs.push('price');
  }

  if (!data.img) {
    errorInputs.push('img');
  }

  return errorInputs;
}

export async function deleteFurniture(id) {
  await del(`/data/catalog/${id}`);
}
