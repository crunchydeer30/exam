/// <reference types="cypress"/>

describe('Тест валидации пароля', () => {
  beforeEach(() => {
    cy.visit('127.0.0.1:5500');
  });

  const todos = [
    {
      title: 'first',
      checked: 'fasle',
      date: '2017-06-01T08:30',
    },
  ];

  it('Первый тест', () => {
    cy.get('#title-input').type('abc');
    cy.get('#date-input').type('2017-06-01T08:30');
    cy.get('#save-button')
      .click()
      .then(() => {
        expect(localStorage.getItem('tasks')).to.eq(
          '[{"id":0,"title":"abc","checked":false,"date":"2017-06-01T08:30"}]'
        );
      });
  });

  it('Второй тест', () => {
    cy.get('#title-input').type('abc');
    cy.get('#date-input').type('2017-06-01T08:30');
    cy.get('#save-button').click();
    cy.get('[type="checkbox"]')
      .check()
      .then(() => {
        expect(localStorage.getItem('tasks')).to.eq(
          '[{"id":0,"title":"abc","checked":true,"date":"2017-06-01T08:30"}]'
        );
      });
    cy.pause();
  });

  it('Третий тест', () => {
    cy.get('#title-input').type('abc');
    cy.get('#date-input').type('2017-06-01T08:30');
    cy.get('#save-button').click();
    cy.get('.task')
      .first()
      .find('button')
      .click()
      .then(() => {
        expect(localStorage.getItem('tasks')).to.eq('[]');
      });
  });
});
