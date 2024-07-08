#!/bin/bash

# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #
#																																																												#
# Task:																																																									#
#																																																												#
# Create a sed script that concatenates lines ending in '-' from a given text if there is no whitespace before the dash	#	#																																																												#
# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #

if [[ "$#" -ne 1 ]]; then
  echo "file not specified or wrong number of arguments"
  exit 1
fi

sed -zE 's/([[:alpha:]])(-\n)/\1/g' "$1"
