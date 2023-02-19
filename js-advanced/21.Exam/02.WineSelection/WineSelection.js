class WineSelection {
  constructor(space) {
    this.space = space;
    this.wines = [];
    this.bill = 0;
  }

  reserveABottle(wineName, wineType, price) {
    if (this.wines.length === this.space) {
      throw new Error('Not enough space in the cellar.');
    }

    const wine = {
      wineName,
      wineType,
      price,
      paid: false,
    };

    this.wines.push(wine);

    return `You reserved a bottle of ${wineName} ${wineType} wine.`;
  }

  payWineBottle(wineName, price) {
    const wine = this.wines.find((w) => w.wineName === wineName);

    if (!wine) {
      throw new Error(`${wineName} is not in the cellar.`);
    }

    if (wine.paid) {
      throw new Error(`${wineName} has already been paid.`);
    }

    wine.paid = true;
    this.bill += price;

    return `You bought a ${wineName} for a ${price}$.`;
  }

  openBottle(wineName) {
    const wine = this.wines.find((w) => w.wineName === wineName);

    if (!wine) {
      throw new Error("The wine, you're looking for, is not found.");
    }

    if (!wine.paid) {
      throw new Error(`${wineName} need to be paid before open the bottle.`);
    }

    const index = this.wines.indexOf(wine);
    this.wines.splice(index, 1);

    return `You drank a bottle of ${wineName}.`;
  }

  cellarRevision(wineType) {
    const result = [];

    let wines;

    if (!wineType) {
      result.push(
        `You have space for ${this.space - this.wines.length} bottles more.`
      );

      result.push(`You paid ${this.bill}$ for the wine.`);

      wines = this.wines.sort((a, b) => a.wineName.localeCompare(b.wineName));
    } else {
      wines = this.wines.filter((w) => w.wineType === wineType);

      if (wines <= 0) {
        throw new Error(`There is no ${wineType} in the cellar.`);
      }
    }

    for (const wine of wines) {
      result.push(
        `${wine.wineName} > ${wine.wineType} - ${
          wine.paid ? 'Has Paid' : 'Not Paid'
        }.`
      );
    }

    return result.join('\n');
  }
}
