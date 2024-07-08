#!/bin/bash

# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #
#																																						  #
# Task:																																			  #
#																																							#
# Write two functions that return (print):																		#
# 	1) a number passed as an argument converted from base 2 - 64 in decimal.  #
# 	2) a number passed as an argument converted from decimal to base 2 - 64.  #
#																																						  #
# The first argument is the base (2 is the default).												  #
#																																						  #
# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #

#helper function to find the character representing the given digit value
get_digit() {
  local digits='0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@_'
  local index=0

  echo "${digits:$remainder:1}"
}

#conversion function from a decimal number to a base 2-64 number
num_encode() {
  local number="$1"
  local base="$2"

  local is_negative=0
  local remainder=0
  local result=""

  #check if the number is negative
  if [ "${number:0:1}" = '-' ]; then
    is_negative=1
    ((number*=-1))
  fi

  #add the remainder of number modulo base to the result, until number is zero
  while [ $number -gt 0 ]; do
    ((remainder=number%base))
    local digit=$(get_digit $remainder)
    result="$digit$result"
    ((number/=base))
  done

  if [ "$is_negative" -eq 1 ]; then
    result="-$result"
  fi

  echo "$result"
}

case $# in
  1)
    num_encode "$1" 2
    ;;
  2)
    num_encode "$1" "$2"
    ;;
  *)
    echo "wrong number of arguments"
    exit -1
esac
