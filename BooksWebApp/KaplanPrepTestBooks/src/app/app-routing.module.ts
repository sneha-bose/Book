import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { BooksComponent } from "./books/books.component";

const routes: Routes =[
    {
        path: "booksearch",
        component: BooksComponent
    },
    {
        path: '',
        redirectTo: "home",
        pathMatch: "full"
    },
    {
        path: "**",
        redirectTo: "/booksearch"
      }
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }