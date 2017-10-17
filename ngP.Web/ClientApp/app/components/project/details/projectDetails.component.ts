import { Component } from "@angular/core";
import { Project } from "../../../model/project";

@Component({
    templateUrl:'./projectDetails.component.html'
})
export class ProjectDetailsComponent
{
    model = new Project('');
}