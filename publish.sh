#!/usr/bin/env bash

success()
{
	echo -e "\033[32m ${1} \033[0m"
}

docker-compose up -d --build  --force-recreate

success "发布镜像成功，镜像Tag为lastest"

docker images|grep none|awk '{print $3}'|xargs docker rmi

success "删除所有为none的镜像"