/// <reference types="cypress"/>

describe('Проверка кнопки "Старт"', () => {
    it('Проверка нажатия кнопки', () => {
        cy.visit('http://127.0.0.1:3002');
        cy.get('button').contains('Старт').click();
        cy.get('h1').should('not.contain', '00:00:00');
        cy.pause();
    })
});

describe('Проверка кнопки "Сброс"', () => {
    it('Проверка нажатия кнопки', () => {
        cy.visit('http://127.0.0.1:3002');
        cy.get('button').contains('Сброс').click();
        cy.get('h1').should('contain', '00:00:00');
        cy.pause();
    })
})
