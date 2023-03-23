import { getUser } from '../util.js';
import { get, post, put, del } from './api.js';

const endpoints = {
  teams: '/data/teams',
  members: '/data/members',
};

export async function getTeams() {
  const teams = await get(endpoints.teams);

  const members = await getMembers(teams.map((team) => team._id));

  teams.forEach((team) => {
    team.memberCount = members.filter(
      (member) => member.teamId === team._id
    ).length;
  });

  return teams;
}

export async function getMembers(teamIds) {
  const query = encodeURIComponent(
    `teamId IN ("${teamIds.join('", "')}") AMD status="member"`
  );

  return await get(`${endpoints.members}?where=${query}`);
}

export async function getTeamById(id) {
  return await get(`${endpoints.teams}/${id}`);
}

export async function createTeam(name, logoUrl, description) {
  const team = await post(endpoints.teams, {
    name,
    logoUrl,
    description,
  });

  console.log(team);

  const request = await requestJoin(team._id);
  await approveRequest(request);

  return team;
}

export async function getRequestsByTeamId(teamId) {
  return await get(
    `${endpoints.members}?where=teamId%3D%22${teamId}%22&load=user%3D_ownerId%3Ausers`
  );
}

export async function requestJoin(teamId) {
  return await post(endpoints.members, {
    teamId,
  });
}

export async function approveRequest(request) {
  debugger;
  console.log(request);

  return await put(`${endpoints.members}/${request._id}`, {
    teamId: request.teamId,
    status: 'member',
  });
}

export async function cancelMembership(id) {
  return await del(`${endpoints.members}/${id}`);
}

export async function getMyTeams() {
  const userId = getUser().id;

  const teamMembership = await get(
    `${endpoints.members}?where=_ownerId%3D%22${userId}%22%20AND%20status%3D%22member%22&load=team%3DteamId%3Ateams`
  );

  const teams = teamMembership.map((r) => r.team);
  const members = await getMembers(teams.map((team) => team._id));

  teams.forEach(
    (team) =>
      (team.memberCount = members.filter((m) => m.teamId == team._id).length)
  );

  return teams;
}

export async function editTeam(id, name, logoUrl, description) {
  return await put(`${endpoints.teams}/${id}`, {
    name,
    logoUrl,
    description,
  });
}
