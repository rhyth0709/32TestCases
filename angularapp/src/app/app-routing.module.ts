import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { EditPlayerComponent } from './edit-player/edit-player.component';
import { AddTeamsComponent } from './add-teams/add-teams.component';
import { AddPlayersComponent } from './add-players/add-players.component';
import { ListPlayersComponent } from './list-players/list-players.component';
import { FormGroup } from '@angular/forms';
import { AdminComponent } from './admin/admin.component';
import { OrganizerComponent } from './organizer/organizer.component';
import { ErrorComponent } from './error/error.component';
import { DeleteplayerComponent } from './deleteplayer/deleteplayer.component';
import { ListTeamsComponent } from './list-teams/list-teams.component';
import { DeleteTeamComponent } from './delete-team/delete-team.component';
const routes: Routes = [ 
  {path:"",component:HomeComponent},
  {path:"addteam",component:AddTeamsComponent},
  {path:"addplayer",component:AddPlayersComponent},
  {path:"edit/:id",component:EditPlayerComponent},
  {path:"listplayer",component:ListPlayersComponent},
  {path:"delete/:id",component:DeleteplayerComponent},
  {path: "listeams",component:ListTeamsComponent},
  {path:"del/:id",component:DeleteTeamComponent},
  {path:"admin",component:AdminComponent},
  {path:"error",component:ErrorComponent},
  {path:"organizer",component:OrganizerComponent}
//edit/:id 
//delete/:id
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
