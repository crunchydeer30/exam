/// <reference types = "cypress" />

describe('my test', () => {
  beforeEach(() => {
    cy.visit('http://192.168.0.100:5500');
  });
});
