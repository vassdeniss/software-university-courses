import { get, post, put, del } from './api.js';

const endpoints = {
  fruitsOrdered: '/data/fruits?sortBy=_createdOn%20desc',
  fruits: '/data/fruits',
};

export async function getFruits() {
  return await get(endpoints.fruitsOrdered);
}

export async function addFruit(fruit) {
  return await post(endpoints.fruits, fruit);
}

export async function getFruitById(id) {
  return await get(`${endpoints.fruits}/${id}`);
}

export async function editFruit(fruit) {
  return await put(`${endpoints.fruits}/${fruit.id}`, fruit);
}

export async function deleteFruit(id) {
  return await del(`${endpoints.fruits}/${id}`);
}

export async function getFruitsByName(name) {
  return await get(`${endpoints.fruits}?where=name%20LIKE%20%22${name}%22`);
}
