from django.shortcuts import render
from django.http import HttpResponse
from rest_framework.decorators import api_view
from rest_framework.response import Response
from rest_framework import status

from .models import *
from .serializers import *

# Create your views here.

def index(request):
  return HttpResponse('Start')

@api_view(['GET', 'POST'])
def tasks(request):

  if request.method == 'GET':
    tasks = Task.objects.all()
    serializer = TaskSerializer(tasks, many=True) 
    return Response(serializer.data, status=status.HTTP_200_OK)
  
  elif request.method == 'POST':
    serializer = TaskSerializer(data=request.data)

    if serializer.is_valid():
      serializer.save()
      return Response(serializer.data, status=status.HTTP_201_CREATED)
    else:
      return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)
  

@api_view(['GET', 'DELETE', 'PUT'])
def task(request, pk):
  
  try:
    Task.objects.get(pk=pk)
  except Task.DoesNotExist:
    return Response(status=status.HTTP_400_BAD_REQUEST)

  task = Task.objects.get(pk=pk)
  
  if request.method == 'GET':
    serializer = TaskSerializer(task, many=False)
    return Response(serializer.data, status=status.HTTP_200_OK)
  
  elif request.method == 'DELETE':
    task.delete()
    return Response(status=status.HTTP_204_NO_CONTENT)

  elif request.method == 'PUT':
    task.checked = not task.checked
    task.save()
    return Response(status=status.HTTP_200_OK)


