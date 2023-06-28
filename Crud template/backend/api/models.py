from django.db import models

# Create your models here.

class Task(models.Model):
  title = models.CharField(max_length=25)
  date = models.DateTimeField(auto_now=True)
  checked = models.BooleanField(default=False)