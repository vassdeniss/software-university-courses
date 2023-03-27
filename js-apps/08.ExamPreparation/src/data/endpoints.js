import { get, post, put, del } from './api.js';

const endpoints = {
  offers: '/data/offers',
  orderedOffers: '/data/offers?sortBy=_createdOn%20desc',
  applications: '/data/applications',
};

export async function getOffersOrdered() {
  return await get(endpoints.orderedOffers);
}

export async function createOffer(
  title,
  imageUrl,
  category,
  description,
  requirements,
  salary
) {
  return await post(endpoints.offers, {
    title,
    imageUrl,
    category,
    description,
    requirements,
    salary,
  });
}

export async function getOfferById(id) {
  return await get(`${endpoints.offers}/${id}`);
}

export async function editOffer(
  id,
  title,
  imageUrl,
  category,
  description,
  requirements,
  salary
) {
  return await put(`${endpoints.offers}/${id}`, {
    title,
    imageUrl,
    category,
    description,
    requirements,
    salary,
  });
}

export async function deleteOffer(id) {
  return await del(`${endpoints.offers}/${id}`);
}

export async function getApplicationsById(id) {
  return await get(
    `${endpoints.applications}?where=offerId%3D%22${id}%22&distinct=_ownerId&count`
  );
}

export async function addApplicationById(id) {
  return await post(endpoints.applications, {
    offerId: id,
  });
}

export async function getApplicationByUserId(offerId, userId) {
  return await get(
    `${endpoints.applications}?where=offerId%3D%22${offerId}%22%20and%20_ownerId%3D%22${userId}%22&count`
  );
}
