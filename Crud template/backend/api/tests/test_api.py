from rest_framework import APITestCase

class TaskApiTestCase(APITestCase):
  def test_get(self):
    url = reverse('tasks')
    print(url)
    response = self.client.get(url)
    print(response)