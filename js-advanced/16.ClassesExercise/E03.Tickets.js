function registerTickets(tickets, criteria) {
  class Ticket {
    constructor(destination, price, status) {
      this.destination = destination;
      this.price = price;
      this.status = status;
    }
  }

  const ticketObjs = [];
  for (const ticket of tickets) {
    let [destination, price, status] = ticket.split('|');
    price = Number(price);
    ticketObjs.push(new Ticket(destination, price, status));
  }

  return ticketObjs.sort((a, b) => {
    if (criteria === 'destination') {
      return a.destination.localeCompare(b.destination);
    }

    if (criteria === 'price') {
      return a.price - b.price;
    }

    if (criteria === 'status') {
      return a.status.localeCompare(b.status);
    }
  });
}

console.log(
  registerTickets(
    [
      'Philadelphia|94.20|available',
      'New York City|95.99|available',
      'New York City|95.99|sold',
      'Boston|126.20|departed',
    ],
    'destination'
  )
);

console.log(
  registerTickets(
    [
      'Philadelphia|94.20|available',
      'New York City|95.99|available',
      'New York City|95.99|sold',
      'Boston|126.20|departed',
    ],
    'status'
  )
);
