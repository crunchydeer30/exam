/// <reference types="cypress"/>

describe('Тест валидации пароля', () => {
  beforeEach(() => {
    cy.visit('127.0.0.1:5500');
  });

  it('Проверка пароля начинающегося с цифр', () => {
    cy.get('input').type('1234abcd');
    cy.get('button').click();
    cy.get('#error-message').should(
      'contain',
      'Пароль не должен начинаться с цифры'
    );
  });

  it('Проверка пароля с двумя нижними подчеркиваниями', () => {
    cy.get('input').type('_12345678_');
    cy.get('button').click();
    cy.get('#error-message').should(
      'contain',
      'Пароль может содержать только один знак подчеркивания'
    );
  });

  it('Проверка пароля без цифр', () => {
    cy.get('input').type('qwerty');
    cy.get('button').click();
    cy.get('#error-message').should(
      'contain',
      'Пароль должен содержать хотя бы одну цифру'
    );
  });

  it('Проверка пароля короче 4 символов', () => {
    cy.get('input').type('123');
    cy.get('button').click();
    cy.get('#error-message').should(
      'contain',
      'Пароль должен быть от 4 до 10 символов'
    );
  });

  it('Проверка пароля длиннее 10 символов', () => {
    cy.get('input').type('qwer12345678_');
    cy.get('button').click();
    cy.get('#error-message').should(
      'contain',
      'Пароль должен быть от 4 до 10 символов'
    );
  });

  it('Проверка пароля не содержащего латинские буквы', () => {
    cy.get('input').type('йцукен1234');
    cy.get('button').click();
    cy.get('#error-message').should(
      'contain',
      'Пароль может содержать только латинские буквы, цифру и знак подчеркивания и быть от 4 до 10 символов'
    );
  });

  it('Проверка валидного пароля', () => {
    cy.get('input').type('qwerty123_');
    cy.get('button').click();
    cy.on('window:alert', (str) => {
      expect(str).to.equal(`Пароль валидный`);
    });
    cy.pause();
  });
});
