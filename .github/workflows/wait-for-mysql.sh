#!/bin/sh

CONTAINER="mysql-principalDatabase"
USERNAME="root"
PASSWORD="123456"
while ! docker exec $CONTAINER mysql --user=$USERNAME --password=$PASSWORD -e "SELECT 1" >/dev/null 2>&1; do
    sleep 1
done