from django.test import TestCase
from rest_framework.test import APITestCase
from django.urls import reverse
from rest_framework import status

# Create your tests here.
class  TestTasks(APITestCase):

  def test_create_task(self):
    sample_task = {'title': 'Unit test'}
    response = self.client.post(reverse('tasks'), sample_task)
    self.assertEqual(response.status_code, status.HTTP_201_CREATED)