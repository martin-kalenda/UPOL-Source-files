#!/bin/bash

# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -	-	#
#																																																					#
# Task:																																																		#
#																																																					#
# Write a program that tries to guess a whole number the user thinks from an 															#
# interval given by two arguments (if one or no arguments are given, the default interval is 0 - 100) 		#
#																																																					#
# The program only asks "is X higher/lower than your number?" and the user replies with either "a" or "n" #
#																																																					#
# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #

guessed=0

left=0
right=100

# check arguments
if [ $# -eq 1 ]; then
  right=$1
elif [ $# -ge 1 ]; then
  left=$1
  right=$2
else
  echo "wrong number of arguments"
  exit -1
fi

# while we have not guessed correctly
while [ $guessed -eq 0 ]; do
	# find the middle of the interval
  let half=($left+$right)/2

	# ask if the user's number is lower than the middle
  echo "je menší než $half?"
  read ans

	# if user answered 'n', ask if number is higher than the middle
  if [ "$ans" = "n" ]; then
    echo "je větší než $half?"
    read ans

		# if user answered 'n', then middle must equal the user's number and we have guessed correctly
    if [ "$ans" = "n" ]; then
      echo "číslo je $half"
      guessed=1
    # if user answered 'a', search in the interval middle - right
    elif [ "$ans" = "a" ]; then
      left=$half
    fi
  # if user answered 'a', search in the interval left - middle
  elif [ "$ans" = "a" ]; then
      right=$half
  fi
done
