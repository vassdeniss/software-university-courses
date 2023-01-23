function modifyWorker(worker) {
  if (worker.dizziness) {
    return {
      ...worker,
      levelOfHydratedWorker: worker.weight * 0.1 * worker.experience,
      dizziness: false,
    };
  }

  return { ...worker };
}

console.log(
  modifyWorker({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true,
  })
);

console.log(
  modifyWorker({
    weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true,
  })
);

console.log(
  modifyWorker({
    weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false,
  })
);
